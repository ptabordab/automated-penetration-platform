import * as log4js from 'log4js';
 


export const runNmapScan = async ( ipaddress_or_cidr: string, config:any) => {

  const logger = log4js.getLogger("runNmapScan()");

  return  new Promise((resolve, reject) =>
  {
    setTimeout(() => {

      let nmap = require('node-nmap');

      try
      {
        const nmapScan = new nmap.NmapScan(ipaddress_or_cidr, '-sT', '-sV');

        
        nmapScan.on('complete', function(data: string) {
          logger.debug(JSON.stringify(data));

          resolve(data);
        });
    
        nmapScan.on('error', function(error: any) {
          logger.error(error);
          reject(error);
        });
    
        nmapScan.startScan();
    
      }
      catch (error)
      {
        logger.error('Error scanning with Nmap:', error);
        reject(error);
      }
    }, config.promises_delay); // Set delay


  });

}
