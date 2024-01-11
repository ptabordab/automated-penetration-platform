import { runNmapScan } from './nmap/runNmapScan';

import { loadConfig } from './shared/loadConfig';
import { StringLiteralLike } from 'typescript';

async function main() {
    try
    {


        const loggerName = "app";

        const version = "1.0.0";

        const config = loadConfig(loggerName);


        logger.info(`Automated Pentesting Platform (APP) , ${version}`)

        const stopwatch = new StopWatch(loggerName);


        // Run Nmap

        stopwatch.start('nmap');

        const nmapResults = await runNmapScan('google.com'), config, logger;

        if(nmapResults)
        {

        }



        stopwatch.stop();

        // Scan with Nessus
        //const nessusScanId = await scanWithNessus(nmapResults);

        // Run Metasploit
        //const metasploitResults = await runMetasploit();

        console.log('Process completed successfully!');


        // Script End
        logger.info(`[main] Short Summary: ${stopwatch.shortSummary()}`);
        logger.info(`[main] Task Count: ${stopwatch.getTaskCount()}`);
        // A table describing all tasks performed
        logger.info(`[main] : ${stopwatch.prettyPrint()}`);


    } catch (error) {
        console.error('Error:', error);
    }
}

main();
