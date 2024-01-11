
var nmap = require('node-nmap');

export async function runNmapScan( cidr: string, config:any, logger:any) : Promise<string> {

  return new Promise(() =>
  {
    setTimeout(() => {
      nmap.nodenmap.nmapLocation = "nmap"; //default

      try
      {
        const quickscan = new nmap.nodenmap.OsAndPortScan(cidr);
    
        quickscan.on('complete', function(data: any) {
          console.log(data);
        });
    
        quickscan.on('error', function(error: any) {
          console.error(error);
        });
    
        quickscan.startScan();
    
      }
      catch (error)
      {
        console.error('Error scanning with Nessus:', error);
        throw error;
      }
    }, config.promise.delay); // Set delay
  });

}
