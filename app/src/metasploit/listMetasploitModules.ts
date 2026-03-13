const axios = require('axios');
import * as log4js from 'log4js';

export const listMetasploitModules = async (token: string, config:any  ) => {

    const logger = log4js.getLogger("listMetasploitModules");

    try 
    {
        const response = await axios.post(`${config.metasploitUrl}/console/module`,
            {
                module: 'auxiliary/scanner/http/http_version'
            },
            {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }
        );
    
        const { modules } = response.data;

        logger.debug(`List of available module: ${modules}`);

        return modules;

    } 
    catch (error: any) 
    {
        logger.error('Failed to List Metasploit Modules:', error.response.data.error);
        throw error;
    }
}