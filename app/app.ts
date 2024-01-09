import { runNmapScan } from './nmap/runNmapScan';


async function main() {
    try {
        // Run Nmap
        const nmapResults = await runNmapScan('google.com');

        // Scan with Nessus
        //const nessusScanId = await scanWithNessus(nmapResults);

        // Run Metasploit
        //const metasploitResults = await runMetasploit();

        console.log('Process completed successfully!');
    } catch (error) {
        console.error('Error:', error);
    }
}

main();
