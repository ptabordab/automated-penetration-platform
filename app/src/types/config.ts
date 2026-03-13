


export class Config
{
    // Application Version
    version: string = '';

    // nmap switches (array)
    nmap_switches: string[] = [];

    // nessus
    nessusUrl               : string = "";
    nessusUsername          : string = "";
    nessusPassword          : string = ""; 
    nessusAccessKey         : string = ""; 
    nessusSecretKey         : string = ""; 
    nessusScanTemplateUUID  : string = "";


    // Database Settings
    dbUri: string = "";
    dbCollection: string = "";

    // metasploit 
    metasploitUrl: string = "";
    metasploitUsername: string = "";
    metasploitPassword: string = "";
   

    // Promise Delay (Time-out)
    promiseDelay: Number = 10;



}