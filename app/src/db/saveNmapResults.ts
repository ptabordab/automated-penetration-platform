const { MongoClient } = require('mongodb');
import * as log4js from 'log4js';

const dateFormat = require('date-format');


export async function saveNmapResults(  nmapResults: any, 
                                        dbClient:any, 
                                        config:any) 
{
    const logger = log4js.getLogger("saveNmapResults");

    let result: any = {};

    dbClient.connect(async(err: any) =>{

    if (err) {
      logger.error('Error connecting to MongoDB:', err);
      return;
    }


    // Select the database
    const database = dbClient.db();

    // Specify the collection
    const collection = database.collection(config.dbCollection);

    const scanDate = dateFormat('yyyy-MM-dd', new Date());
    const scanTime = dateFormat('hh:mm:ss', new Date());

    let nmapResultsToInsert: any[] = [];

    if(Array.isArray(nmapResults))
    {
      // In case nmapResultss contains an array of hosts
      nmapResultsToInsert = [...nmapResults];
    }
    else
    {
      // In case nmapResults is a single hosts, we still want it to be an array 
      nmapResultsToInsert.push(nmapResults);
    }

    // Document to be inserted
    const scanDocument = {
      ScanDate : scanDate,
      ScanTime : scanTime,
      nmap     : nmapResultsToInsert
    };

    try
    {
      // Insert a single document
      result = await collection.insertOne(scanDocument);
    
      logger.debug('Document inserted:', result.insertedId);
    } 
    finally 
    {
      // Close the connection
      dbClient.close();
    }

  });

  return result;
}
 



