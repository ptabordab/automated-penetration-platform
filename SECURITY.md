## Security Guide

This document summarizes key security practices for developing and operating the Automated Penetration Platform (APP).

### 1. Secrets management

- **Never commit secrets** (passwords, API keys, activation codes, connection strings, tokens) to git.
- **App configuration**:
  - Use `app/src/config.example.json` as the template.
  - Copy it to `app/src/config.json` locally and fill in values **only on your machine**.
  - `config.json` is ignored via `.gitignore` and must not be committed.
- **Environment variables (preferred)**:
  - APP now reads from env vars first, then falls back to `config.json`:
    - `NESSUS_URL`, `NESSUS_USERNAME`, `NESSUS_PASSWORD`
    - `NESSUS_ACCESS_KEY`, `NESSUS_SECRET_KEY`, `NESSUS_TEMPLATE_UUID`
    - `MONGODB_URI`, `MONGODB_COLLECTION`
    - `METASPLOIT_URL`, `METASPLOIT_USERNAME`, `METASPLOIT_PASSWORD`
    - `PROMISE_DELAY_MS`
  - For local development you can use a shell profile or a local `.env` file (not committed).
- **Docker secrets / env**:
  - Use `docker/.env.example` as the template.
  - Copy it to `docker/.env` and populate strong passwords:
    - `SPLUNK_PASSWORD`
    - `MONGODB_INITDB_ROOT_USERNAME`, `MONGODB_INITDB_ROOT_PASSWORD`
    - `NESSUS_USERNAME`, `NESSUS_PASSWORD`, `NESSUS_ACTIVATION_CODE`
  - Do **not** commit `docker/.env`.

### 2. Log hygiene

- APP previously logged full config objects (including secrets). This has been hardened:
  - `getConfig()` now logs a **redacted** summary.
  - Default log level is **`info`** instead of `debug`.
- Recommendations:
  - Only enable `debug` logging for short-lived local troubleshooting sessions.
  - Never log raw tokens, passwords, API keys, or connection strings.
  - Regularly rotate and securely store log archives; delete them when no longer needed.

### 3. Network exposure and Docker

- Docker compose now:
  - Binds exposed ports to `127.0.0.1` (local-only access by default).
  - Pulls sensitive values from `docker/.env`.
- When running outside a lab:
  - Avoid exposing Metasploitable2 and other intentionally vulnerable services beyond the local host.
  - If you must expose services on the network, place them behind a firewall/VPN and restrict access by IP.

### 4. Dependency security

- Use `npm audit` regularly in `app/src` to detect known vulnerabilities:
  - `cd app/src`
  - `npm audit`
  - `npm audit fix` when appropriate, then re-test.
- Keep high-risk packages (e.g. `axios`) up to date.

### 5. Input validation and command usage

- APP accepts a target (`IP / CIDR / hostname`) on the CLI and passes it into `node-nmap`.
- Best practices:
  - Validate input to ensure it is a **valid IP/CIDR/hostname** (no shell metacharacters).
  - Prefer libraries that use safe argument arrays when spawning processes.
  - If adding new features that invoke external tools, never build command lines by simple string concatenation on untrusted input.

### 6. If secrets have already been pushed

If real credentials or keys were ever pushed to a remote (e.g., GitHub), assume they are compromised.

1. **Rotate secrets** at the providers:
   - MongoDB root password
   - Nessus user password, access key, secret key, activation code
   - Splunk admin password
   - Any other passwords or tokens reused elsewhere
2. **Purge old secrets from git history (optional but recommended)**:
   - Use Git tooling such as:
     - `git filter-repo` (preferred, maintained)
     - or the GitHub BFG-style tools
   - Remove files/lines containing old secrets from history.
   - Force-push cleaned branches **only after** rotation is complete and you understand the impact (`git push --force-with-lease`).
3. **Notify affected systems/users** and update any out-of-band documentation that referenced the old secrets.

### 7. Operational security for a pen-test platform

- Run APP and its supporting containers in **isolated lab networks** whenever possible.
- Do not point the platform at production assets without proper authorization and scope.
- Treat generated data (scan results, logs, reports) as sensitive; store and transmit it securely.

### 8. Quick checklist before sharing the repo

- [ ] `git status` shows no `config.json`, `.env`, or other local secret files.
- [ ] `app/src/config.json` (if present) contains **no real credentials**.
- [ ] `docker/.env` is **not** committed; only `docker/.env.example` is.
- [ ] `npm audit` in `app/src` reports **0 vulnerabilities**, or remaining ones are documented and accepted.
- [ ] README and this `SECURITY.md` are up to date with how you actually deploy APP.

