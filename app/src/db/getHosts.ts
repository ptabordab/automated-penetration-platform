const { MongoClient } = require('mongodb');
import * as log4js from 'log4js';
import { ObjectId } from 'mongodb';
import { Host } from '../types/host'



export async function getHosts( scanDocumentId:ObjectId, 
                                dbClient:any,
                                config: any) 
{
    const logger = log4js.getLogger("getHosts");

    let result: any = {};

    let hosts: Host[] = [];

    dbClient.connect(async(err: any) =>{
        if (err) {
            logger.error('Error connecting to MongoDB:', err);
            return;
          }
      
      
          // Select the database
          const database = dbClient.db();
      
          // Specify the collection
          const collection = database.collection(config.dbCollection);

          try
          {
            result = await collection.findOne({ _id: new ObjectId(scanDocumentId) });

            if (result) 
            {
  
              const hostsFound:any [] = result.nmap;
  
              hostsFound.forEach(element => {

                // [  
                //    {  
                //       "hostname":"localhost",
                //       "ip":"127.0.0.1",
                //       "mac":null,
                //       "openPorts":[  
                
                //       ],
                //       "osNmap":null
                //    },
                //    {  
                //       "hostname":"google.com",
                //       "ip":"74.125.21.113",
                //       "mac":null,
                //       "openPorts":[  
                
                //       ],
                //       "osNmap":null
                //    }
                // ]

                let host:Host = new Host();

                host.hostname = element.hstname;
                host.ipAddress = element.ip;
                host.macAddress = element.mac;
                host.openPorts = element.opoenPorts;

                hosts.push(host);

                
              });
                
              console.log(`IP address for document with _id ${scanDocumentId}: ${JSON.stringify(hosts)}`);
            } 
            else 
            {
              console.log(`Document with _id ${scanDocumentId} not found.`);
            }
    
          } 
          finally 
          {
            // Close the connection
            dbClient.close();
          }           
         
  

    });


    return hosts;
}
