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

    let configJson: any = {};
    try
    {
        configJson = JSON.parse(fs.readFileSync('config.json', 'utf-8'));
    }
    catch (e:any)
    {
        logger.warn(`config.json not found/readable; relying on environment variables`);
    }


    config.nmap_switches  = (configJson?.nmap?.switches ?? []);

    config.nessusUrl                = process.env.NESSUS_URL           || configJson?.nessus?.url || "";
    config.nessusUsername           = process.env.NESSUS_USERNAME      || configJson?.nessus?.username || "";
    config.nessusPassword           = process.env.NESSUS_PASSWORD      || configJson?.nessus?.password || "";
    config.nessusAccessKey          = process.env.NESSUS_ACCESS_KEY    || configJson?.nessus?.accessKey || "";
    config.nessusSecretKey          = process.env.NESSUS_SECRET_KEY    || configJson?.nessus?.secretKey || "";
    config.nessusScanTemplateUUID   = process.env.NESSUS_TEMPLATE_UUID || configJson?.nessus?.templateUUID || "";

    config.dbUri         = process.env.MONGODB_URI         || configJson?.db?.uri || "";
    config.dbCollection  = process.env.MONGODB_COLLECTION  || configJson?.db?.collection || "";


    config.metasploitUrl      = process.env.METASPLOIT_URL      || configJson?.metasploit?.url || "";
    config.metasploitUsername = process.env.METASPLOIT_USERNAME || configJson?.metasploit?.username || "";
    config.metasploitPassword = process.env.METASPLOIT_PASSWORD || configJson?.metasploit?.password || "";


    const envPromiseDelay = process.env.PROMISE_DELAY_MS ? Number(process.env.PROMISE_DELAY_MS) : undefined;
    const jsonPromiseDelay = configJson?.promise?.delay;
    config.promiseDelay = (Number.isFinite(envPromiseDelay) ? envPromiseDelay : (jsonPromiseDelay ?? 10));




    logger.debug(`Configuration loaded (secrets redacted): ${JSON.stringify({
        version: config.version,
        nmap_switches: config.nmap_switches,
        nessusUrl: config.nessusUrl,
        nessusUsername: config.nessusUsername ? '[set]' : '',
        dbUri: config.dbUri ? '[set]' : '',
        dbCollection: config.dbCollection,
        metasploitUrl: config.metasploitUrl,
        metasploitUsername: config.metasploitUsername ? '[set]' : '',
        promiseDelay: config.promiseDelay
    })}`);

    return config;
}