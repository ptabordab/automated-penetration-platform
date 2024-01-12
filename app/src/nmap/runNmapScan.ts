import * as log4js from 'log4js';
var nmap = require('node-nmap');

export const runNmapScan = async ( cidr: string, config:any) => {

  const logger = log4js.getLogger("getConfig()");

  const response =  new Promise(() =>
  {
    setTimeout(() => {
      nmap.nodenmap.nmapLocation = "nmap"; //default

      try
      {
        const quickscan = new nmap.nodenmap.OsAndPortScan(cidr);
    
        quickscan.on('complete', function(data: any) {
          logger.debug(data);
        });
    
        quickscan.on('error', function(error: any) {
          logger.error(error);
        });
    
        quickscan.startScan();
    
      }
      catch (error)
      {
        logger.error('Error scanning with Nessus:', error);
        throw error;
      }
    }, config.promise.delay); // Set delay
  });


  return response;

}
