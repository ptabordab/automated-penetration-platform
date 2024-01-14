import * as log4js from 'log4js';
import fs from 'fs';
import { Config } from '../types/config';

export const getConfig = () : Config =>
{

    const logger = log4js.getLogger("getConfig()");

    logger.info('Retrieving configuration settings');

    let config:Config = new Config();


    let packageJson = JSON.parse(fs.readFileSync('package.json', 'utf-8'));

    config.version = packageJson.version;

    let configJson = JSON.parse(fs.readFileSync('config.json', 'utf-8'));


    config.nmap_switches  = configJson.nmap.switches;

    config.nessusUrl                = configJson.nessus.url;
    config.nessusUsername           = configJson.nessus.username;
    config.nessusPassword           = configJson.nesuss.password;
    config.nessusApiKey             = configJson.nesuss.apiKey;
    config.nessusApiToken           = configJson.nesuss.apiToken;
    config.nessusScanTemplateUUID   = configJson.nessus.templateUUID;

    config.dbUri         = configJson.db.uri;
    config.dbCollection  = configJson.db.collection;
 
    config.metasploitUrl      = configJson.metasploit.url;
    config.metasploitUsername = configJson.metasploit.username;
    config.metasploitPassword = configJson.metasploit.password;


    config.promiseDelay = configJson.promise.delay;




    logger.debug(`Configuration: ${JSON.stringify(config)}`);

    return config;
}