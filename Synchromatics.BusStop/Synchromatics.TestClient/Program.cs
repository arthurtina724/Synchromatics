using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Topshelf;

namespace Synchromatics.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(x =>                                 
            {
                x.Service<ArrivalTimeProcess>(s =>                        
                {
                    s.ConstructUsing(name => new ArrivalTimeProcess());     
                    s.WhenStarted(tc => tc.Start());              
                    s.WhenStopped(tc => tc.Stop());               
                });
                x.RunAsLocalSystem();                            

                x.SetDescription("Get Arrival Times for a Given Stop");        
                x.SetDisplayName("Arrvial Time Client");                       
                x.SetServiceName("Synchromatics.ArrivalTimeJob");                       
            });
          
        }
    }
}
