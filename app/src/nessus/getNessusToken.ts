import * as log4js from 'log4js';
const axios = require('axios');


export const getNessusToken = async (config:any) => {

    const logger = log4js.getLogger("getNessusToken");

   try
   {
        const response = await axios.post(`${config.nessusApiUrl}/session`, {
     		      username: config.nessusUsername,
     		      password: config.nessusPassword
        });

        const token = response.data.token;
   		
        // Return the obtained token
        return token;
    } 
    catch (error: any) 
    {
        logger.error(error);
        throw new Error(`Login failed: ${error.message}`);
    }

}





