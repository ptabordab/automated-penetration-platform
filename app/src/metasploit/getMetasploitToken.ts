import * as log4js from 'log4js';
const axios = require('axios');


export const getMetasploitToken = async (config:any) => {

    const logger = log4js.getLogger("getMetasploitToken");


   try
   {
        const response = await axios.post(`${config.metasploitUrl}/login`, {
     		      username: config.metasploitUsername,
     		      password: config.metasploitPassword
        });

        const token = response.data.token;
   		
        // Return the obtained token
        return token;
    } 
    catch (error: any) 
    {
        throw new Error(`Login failed: ${error.message}`);
    }

}





