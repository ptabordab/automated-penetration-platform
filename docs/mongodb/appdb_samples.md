# Sample data for app-db Collection

app-db> db.discoveries.find()
[
  {
    _id: ObjectId('65a4d3b42df8c8fb115883fe'),
    ScanDate: '2024-01-15',
    ScanTime: '01:41:56',
    nmap: [
      {
        hostname: null,
        ip: '172.18.1.5',
        mac: null,
        openPorts: [
          {
            port: 21,
            protocol: 'tcp',
            service: 'ftp',
            method: 'table'
          },
          {
            port: 22,
            protocol: 'tcp',
            service: 'ssh',
            method: 'table'
          },
          {
            port: 23,
            protocol: 'tcp',
            service: 'telnet',
            method: 'table'
          },
          {
            port: 25,
            protocol: 'tcp',
            service: 'smtp',
            method: 'table'
          },
          {
            port: 80,
            protocol: 'tcp',
            service: 'http',
            method: 'table'
          },
          {
            port: 111,
            protocol: 'tcp',
            service: 'rpcbind',
            method: 'table'
          },
          {
            port: 139,
            protocol: 'tcp',
            service: 'netbios-ssn',
            method: 'table'
          },
          {
            port: 445,
            protocol: 'tcp',
            service: 'microsoft-ds',
            method: 'table'
          },
          {
            port: 512,
            protocol: 'tcp',
            service: 'exec',
            method: 'table'
          },
          {
            port: 513,
            protocol: 'tcp',
            service: 'login',
            method: 'table'
          },
          {
            port: 514,
            protocol: 'tcp',
            service: 'shell',
            method: 'table'
          },
          {
            port: 1099,
            protocol: 'tcp',
            service: 'rmiregistry',
            method: 'table'
          },
          {
            port: 1524,
            protocol: 'tcp',
            service: 'ingreslock',
            method: 'table'
          },
          {
            port: 2121,
            protocol: 'tcp',
            service: 'ccproxy-ftp',
            method: 'table'
          },
          {
            port: 3306,
            protocol: 'tcp',
            service: 'mysql',
            method: 'table'
          },
          {
            port: 5432,
            protocol: 'tcp',
            service: 'postgresql',
            method: 'table'
          },
          {
            port: 6667,
            protocol: 'tcp',
            service: 'irc',
            method: 'table'
          },
          {
            port: 8009,
            protocol: 'tcp',
            service: 'ajp13',
            method: 'table'
          },
          {
            port: 8180,
            protocol: 'tcp',
            service: 'unknown',
            method: 'table'
          }
        ],
        osNmap: null
      }
    ]
  }
]
