
import fs from 'fs';
import { Config } from '../types/config';

export const getConfig = (logger: any) : Config =>
{

    logger.info('Retrieving configuraion settings');

    let config:Config = new Config();


    let packageJson = JSON.parse(fs.readFileSync('package.json', 'utf-8'));

    config.version = packageJson.versiion;

    logger.debug(`Coonfiguration: ${JSON.stringify(config)}`);

    return config;
}