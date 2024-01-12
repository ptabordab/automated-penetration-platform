import { runNmapScan } from './nmap/runNmapScan';
import * as log4js from 'log4js';
import { StopWatch } from 'stopwatch-node';
import { getConfig } from './shared/getConfig';

async function main() {
    try
    {


        const loggerName = "app";

        log4js.configure('log4js.config');

        const logger = log4js.getLogger(loggerName);

        const config = getConfig();

        logger.info(`Automated Penetration Platform (APP) , ${config.version}`);
        logger.info(`Copyright (c) 2024 - Rob McAfee <rob.mcafee@symtech.com>, Phil Santos <phil.adrian.santos@gmail.com>, Pedro Taborda <taborda_pedro@yahoo.com>`);


        const stopwatch = new StopWatch(loggerName);


        // Run Nmap

        stopwatch.start('nmap');

       
        const nmapResults = await runNmapScan('google.com', config);

        logger.debug(`Processing nmap results `);

        logger.debug(nmapResults);

        


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


        log4js.shutdown(() => true);


    } 
    catch (error) 
    {
        console.error('Error:', error);
    }
}

main();
