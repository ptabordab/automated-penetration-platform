const { MongoClient } = require('mongodb');


async function insersaveNmapResult( nmapResults: string, 
                                    dbClient:any, 
                                    config:any, 
                                    logger: any) 
{
  try 
  {
    // Connect to the MongoDB server
    await dbClient.connect();

    // Select the database
    const database = dbClient.db(config.db.name);

    // Specify the collection
    const collection = database.collection(config.db.collection);

    // Insert the document into the collection
    const result = await collection.insertOne(nmapResults);

    logger.info(`Document inserted with _id: ${result.insertedId}`);
  } 
  finally 
  {
    // Close the client
    await dbClient.close();
  }
}
 



