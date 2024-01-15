import { runNmapScan } from './nmap/runNmapScan';
import * as log4js from 'log4js';
import { StopWatch } from 'stopwatch-node';
import { getConfig } from './shared/getConfig';
import { getNessusToken } from './nessus/getNessusToken';
import { getMetasploitToken } from './metasploit/getMetasploitToken';
import { listMetasploitModules } from './metasploit/listMetasploitModules';
import { MongoClient, ObjectId } from 'mongodb';
import { saveNmapResults } from './db/saveNmapResults';

async function main() {
    try
    {


        const loggerName = "app";

        log4js.configure('log4js.config');

        const logger = log4js.getLogger(loggerName);

        const config = getConfig();

        logger.info(`Automated Penetration Platform (APP) , ${config.version}`);
        logger.info(`Copyright (c) 2024 - Rob McAfee <rob.mcafee@symtech.com> `);
        logger.info(`                     Phil Santos <phil.adrian.santos@gmail.com> `);
        logger.info(`                     Pedro Taborda <taborda_pedro@yahoo.com>`);

        if( process.argv.length ===  2)
        { 
            logger.error(`Usage: node app.js <IP Address>, node app.js 172.18.1.4`);
            logger.error('       node app.js <CIDR>       , node app.js 172.18.1.0/24');
            logger.error('       node app.js <hostname>   , node app.js mycomputer.local ');

            log4js.shutdown(() => true);

            process.exit(-1);
        }
        else
        {
            const stopwatch = new StopWatch(loggerName);

            // Authenticate and get the session token from Nessus & Metasploit Framework

            stopwatch.start('init');

            logger.debug(`Login to Nessus`);
            //const nessusSessionToken = await getNessusToken(config);

            logger.debug(`Login to Metasploit Framework`);
            //const metasploitSessionToken = await getMetasploitToken(config);

            logger.debug('Lising Metasploit Modules available');
            //const metasploitModules = await listMetasploitModules(metasploitSessionToken, config);

            stopwatch.stop();

                
            // Run Nmap
    
            stopwatch.start('nmap');
    
            let isEmpty = require('lodash.isempty');
           
            const nmapResults = await runNmapScan( process.argv[2], config);
    
            if(!isEmpty(nmapResults))
            {
                logger.debug(`Processing nmap results `);
    
                logger.debug(nmapResults);

                const client = new MongoClient(config.dbUri, {  });

                logger.debug(client);

                // Save results into the database 
                logger.debug(`Saving nmap results to the database`);
                const scanDocId:ObjectId = await saveNmapResults(nmapResults, client, config);
                
            }
            else
            {
                logger.warn(`nmap did not return any results, check your input parameter`);
            }
    
            stopwatch.stop();
    
            // Scan with Nessus
            //const nessusScanId = await scanWithNessus(nmapResults);
    
            // Run Metasploit
            //const metasploitResults = await runMetasploit();
    
            console.log('Process completed successfully!');
    
    
            // Script End
            logger.info(`Short Summary: ${stopwatch.shortSummary()}`);
            logger.info(`Task Count: ${stopwatch.getTaskCount()}`);
            // A table describing all tasks performed
            logger.info(` :${stopwatch.prettyPrint()}`);
        }


        log4js.shutdown(() => true);


    } 
    catch (error) 
    {
        console.error('Error:', error);
    }
}

main();
