# Assignment Azure Functions

**Student:**        Bram Terlouw    <br/>
**Studentnumber:**  614992          <br/>
**Teacher:**        Frank Dersjant

## Desciption of codebase:
Project gebouwd in n-tier architectuur. Bevat twee Azure functions die beide getriggered worden met een http reguest. Eerste function ontvangt een call via een Github Action van repository: [Target Github Repository](https://github.com/BramTerlouw/Github-Webhook)

Github data wordt opgeslagen in een Azure Table Storage en doorgestuurd naar een Slack bot die het bericht weergeeft in een Slack Channel.

Tweede function haalt alle data op uit de Azure Table storage en returned deze naar de client wanneer de function wordt aangeroepen met een GET request.

## Steps to run:

**Step 1:** <br/>
Run Azure function project

**Step 2:** <br/>
ngrok http {port of azure function} --name=localhost

**Step 3:** <br/>
- Add ngrok domain address to YAML of Github Action.
- Save and Commit change.

## Usage:
1. Commit Change in branch of repository.<br/>
2. Open Slack to see notification of push in channel.
3. Make a **Get** request to URL of Azure function for fetching data.