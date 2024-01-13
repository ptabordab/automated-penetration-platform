


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
    nessusApiKey            : string = ""; 
    nessusApiToken          : string = ""; 
    nessusScanTemplateUUID  : string = "";


    // Database Settings
    dbUri: string = "";
    dbCollection: string = "";

    // Promise Delay (Time-out)
    promiseDelay: Number = 10;



}