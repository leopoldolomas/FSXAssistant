//--------------------------------------------------------------- @License begins
// "FSXAssistant"
// 2015 Leopoldo Lomas Flores. Torreon, Coahuila. MEXICO
// leopoldolomas [at] gmail
// www.leopoldolomas.info
// 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or distribute this
// software, either in source code form or as a compiled binary, for any purpose,
// commercial or non-commercial, and by any means.
// 
// In jurisdictions that recognize copyright laws, the author or authors of this
// software dedicate any and all copyright interest in the software to the public
// domain. We make this dedication for the benefit of the public at large and to
// the detriment of our heirs and successors. We intend this dedication to be
// an overt act of relinquishment in perpetuity of all present and future
// rights to this software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//--------------------------------------------------------------- @License ends

using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace FSXAssistantServer
{
    static class Program
    {
        private static ServiceHost serviceHost = null;
        private static FSXAssistantService service = null;
        private static string serverPort = "9000";

        private static void startService()
        {
            String baseAddress = "net.tcp://localhost:" + serverPort + "/FSXAssistant";
            Console.WriteLine(Environment.NewLine + "Starting FSXAssistantServer at address: " + baseAddress + "...");

            try
            {
                serviceHost = new ServiceHost(typeof(FSXAssistantService), new Uri(baseAddress));
                serviceHost.AddServiceEndpoint(typeof(IFSXAssistant), new NetTcpBinding(), "");

                ServiceMetadataBehavior metadataBehavior = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (metadataBehavior == null)
                {
                    metadataBehavior = new ServiceMetadataBehavior();
                }
                serviceHost.Description.Behaviors.Add(metadataBehavior);
                serviceHost.AddServiceEndpoint(
                    ServiceMetadataBehavior.MexContractName,
                    MetadataExchangeBindings.CreateMexTcpBinding(),
                    "mex");

                serviceHost.Open();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (serviceHost != null && serviceHost.State == CommunicationState.Opened)
            {
                Console.WriteLine("Server successfully started!");
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("FSXAssistantServer v0.1");
            Console.WriteLine("2015 - Leopoldo Lomas Flores");
            Console.WriteLine("leopoldolomas@gmail.com");
            Console.WriteLine("");
            Console.WriteLine("This project was released under the public domain,");
            Console.WriteLine("for more information please visit:");
            Console.WriteLine("http://leopoldolomas.info");
            Console.WriteLine("---------------------------------------------------------");

            service = new FSXAssistantService();
            bool connectionSuccessful = service.SimConnect_Start();

            if (!connectionSuccessful)
            {
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
            else
            {
                startService();
            }

            while (connectionSuccessful && true)
            {
                string input = Console.ReadLine().Trim().ToLower();
                if (input.StartsWith("start"))
                {
                    var lines = input.Split(' ');
                    serverPort = lines.Length > 1 ? lines[1] : "9000";

                    if (serviceHost == null)
                    {
                        startService();
                    }
                    else
                    {
                        Console.WriteLine("Service already started.");
                    }
                }
                else if (input.Equals("stop"))
                {
                    if(serviceHost != null && serviceHost.State == CommunicationState.Opened)
                    {
                        serviceHost.Close();
                        serviceHost = null;
                        Console.WriteLine("Service stopped.");
                    }
                    else
                    {
                        Console.WriteLine("Service not started yet.");
                    }
                }
                else if (input.Equals("exit"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command not recognized.");
                }
            }
        }
    }
}
