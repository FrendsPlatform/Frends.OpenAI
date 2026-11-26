# Frends.OpenAI.CallChatGPT

Task for calling OpenAI's Chat GPT API.

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Build](https://github.com/FrendsPlatform/Frends.OpenAI/actions/workflows/CallChatGPT_main_release.yml/badge.svg)](https://github.com/FrendsPlatform/Frends.OpenAI/actions)
![Coverage](https://app-github-custom-badges.azurewebsites.net/Badge?key=FrendsPlatform/Frends.OpenAI/Frends.OpenAI.CallChatGPT|main)

## Installing

You can install the Task via frends UI Task View.

## Building

### Clone a copy of the repository

`git clone https://github.com/FrendsPlatform/Frends.OpenAI.git`

### Build the project

`dotnet build`

### Run tests

Run the tests

`dotnet test`

For integration tests, set `OPENAI_API_KEY` in your environment or copy
`Frends.OpenAI.CallChatGPT.Tests/.env.example` to
`Frends.OpenAI.CallChatGPT.Tests/.env` and replace the example value with your key.
The local `.env` file is ignored by Git; an existing environment variable takes precedence.

### Create a NuGet package

`dotnet pack --configuration Release`

### Third-party licenses

SonarAnalyzer.CSharp version (unmodified version 9.8.0.76515) used to analyze bugs, vulnerabilities and code smells uses LGPLv3, full text and source code can be found in https://github.com/SonarSource/sonar-dotnet.
