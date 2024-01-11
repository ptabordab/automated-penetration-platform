
export async function loadConfig( configFilePath: string, loggerName: string) {

// Create default logger until the target log file is read from the configuration file
   var loggerBootConfig = {appenders: {}, categories: {default: {appenders: [name], level: 'info'}}};
   loggerBootConfig.appenders[name] = {type: 'fileSync', filename: 'err.log', maxLogSize: 10458760, backups: 10};

   log4js.configure(loggerBootConfig);

   var logger = log4js.getLogger(name);

   logger.info('[main] Script init');

   // Redirect logging to the target log file in the configuration file
    try
    {
        log4js.configure(conf.log);

        logger = log4js.getLogger(name);

        logger.info('[main] Script init');
    }
    catch(err)
    {
        // Can't log to the target file => error and stop
        logger.error('[main] Unable to configure Logging System using: ' + conf.log);
        scriptEnd(logger, 3);
    }

    return config;
 }
