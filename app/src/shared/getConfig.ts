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


    config.db_uri         = configJson.db.uri;
    config.db_name        = configJson.db.name;
    config.db_collection  = configJson.db.collection;
    config.db_username    = configJson.db.username;
    config.db_password    = configJson.db.password;
 
    config.promise_delay = configJson.promise.delay;

    logger.debug(`Configuration: ${JSON.stringify(config)}`);

    return config;
}