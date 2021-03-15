using Shared.Interfaces;
using System;
using System.ServiceModel;

namespace Shared.Client
{
    public class RunClient
    {
        public static DetailObject Execute(string address,
                                          string nameString)
        {
            DetailObject details;
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(new Uri(string.Format(address, Environment.MachineName)));
            var channelFactory = new ChannelFactory<IHelloWorldService>(binding, endpoint);
            var serviceClient = channelFactory.CreateChannel();

            try
            {
                details = serviceClient.GetDetailObject(nameString);
            }
            catch (System.ServiceModel.CommunicationException)
            {
                string str = $"Exception getting detail object";
                //Console.WriteLine(str);
                details = new DetailObject
                {
                    HelloString = str,
                    NameString = nameString,
                    FromString = address,
                    Count = 0
                };
            }
            catch (Exception ex)
            {
                string str = $"Exception getting detail object {ex}";
                Console.WriteLine(str);
                details = new DetailObject
                {
                    HelloString = str,
                    NameString = nameString,
                    FromString = address,
                    Count = 0
                };
            }
            finally
            {
                channelFactory.Close();
            }

            return details;
        }
    }
}