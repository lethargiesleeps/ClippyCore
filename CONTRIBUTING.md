# Contributing to ClippyAI and/or ClippyCore

Thanks for your interest in contributing! We welcome bug reports, feature requests, improvements and pull requests.
We want to foster an open and accepting development environment for people who are passionate about this tech, or just simply want to learn.

Our goal is to make this project a great space for seasoned and new contributors to an open source project.

## How to Contribute

### Reporting Bugs and Requesting Features
- Please use the provided GitHub Issue templates (template_xxxx.md).
- Before submitting a bug, please search existing issues to see if it has already been reported.
- Please label your GitHub Issue appropriately (bug, feature-request, etc...)
- Please also label your GitHub Issue with the related Project label it targets (clippy-core, clippy-desktop, clippy-word)


### Submitting Code Changes (Pull Requests)
1. **Fork** the repository on GitHub if not already done.
2. **Clone** your forked repository to your local machine if not already done.
   1. pull origin from the target branch before branching off, or make sure when you are creating a new branch it is up to date.
3. Create a **new** branch for your feature or bugfix. 
   1. Please base your new branch off the respective project's branch (clippy-core, clippy-desktop, clippy-word, clippy-testing, etc...)
   2. Branch name doesn't really matter. You can use the Issue # if preferred but we have no standard in regards to branch names.
   3. If creating new classes, interfaces, implemntations, methods, etc... Please use XMLDoc-style documentation and provide clear, descriptive info. PRs will not be accepted until all documentation related issues are resolved. We will generate the documentation if your PR includes new documentation.
   4. Please try your best to follow the recommended C# coding conventions.
   5. Try not leave Debug.WriteLine's in the code. Use our Logger.Log if necessary
   6. Don't worry too much unused namespaces/variables. We'll run a code cleanup before any big push to the dev branch,
4. Make your changes and commit them with clear, descriptive messages.
5. Push your changes to your fork on GitHub.
6. Go to the original repository and you will see a prompt to open a Pull Request. You can optionally use the `template_pull_request.md` template for a meaningful PR description. 
   - Please target the correct branch (don't target main, dev, or a release branch please)
   - Your PR shouldn't ever modify more than 1 project with the exception of ClippyTesting
7. Fix merge conflicts if necessary, reach out if you need help.
8. An admin/approved contributor will review your PR. They may request changes, please resolve changes accordingly. If PR is rejected, a detailed explaination will be provided.

### Branch Structure & Git Workflow Stuff
- main
   - release-x.x.1
   - release-x.x.2 (so on and so forth, stale release branches should be deleted periodically... try to keep branches where the last decimal is 0 unless they are very old and stole)
   - dev
      - clippy-core
         - my-hotfix-1 (branch off clippy-core if you you're changes are in this project)
      - clippy-desktop
         - my-hotfix-2 (same as above but for ClippyDesktop)
      - clippy-word
         - some-random-feature (same as previous too but for ClippyWord)
      - clippy-testing
         - add-new-unit-test (same stuff here)

**Branch Workflow**
- Contributions get merged with their respective branch. An admin will merge the clippy-xxxx branches to dev.
- Project branches get merged to dev by an Admin.
- dev gets merged to the appropriate release branch by an Admin.
- Appropriate release branch gets merged to main by an Admin


### Becoming an Admin/Approved Contributor
Becoming an Admin/Approved Contributor will grant you more decision-making power in the direction of this project. You will be able to approve PRs, deploy releases, not working off a fork and moderate other contributors amongst other things. You can ask Michael or another Admin if you could become a project Admin/Approved contributor or we may reach out to you! Decision will be made if you demonstrate the following:
- Contribute meaningfully a lot
- Contributions and PRs follow the PR workflow and code of conduct
- Engage with Admins and other contributors
- Care about the project
- Provide a nurturing learning environment for other developers old and new
- Can provide constructive criticism on other contributor's work
- Are a nice person

Becoming an Admin doesn't add expectations in terms of work. You do stuff at your own pace in your own time, always. No one should ever hawk over you if you are not checking PRs or resolvin X issues per week. If you ever feel pressured to deliver anything, something isn't right and you should let us know right away. Being inactive for an extended period of time is fine, no explaination should ever be needed. This is and always be just a passion project, not a workplace. Yes, mistakes can happen and should serve to learn form. Bad code will not revoke your privileges unless it is extremely consistent. That being said however, failure to follow rules outlined in **Some Code of Conduct Stuff and Some Rules** or any abuse of privilege will result in a prompt expulsion from this project.

### Submitting a New Agent
If you are feeling artistic, there are ways you can create your own MS Agents. We are open to adding custom .acs files to the repo and adding them to ClippyCore! If the agent you made is 100% your own original character we will properly credit/attribute you and add any relevant links to your work. That being said, there are a few things to consider:
- Please submit your Agent via a Pull Request (PR). If you are not certain on how you can reach out or refer to the above section **Submitting
- Please provide a list of animation names in your commit or PR descriptions (format can be camelCase, PascalCase, snake_case or some logical combo of the 3)
- Please mention whether or not your Agent has TTS capabilities in your commit or PR descriptions. If it does, please provide the TTSModeID.
- PR to add the animations in Global/Animations.cs if you are comfortable doing that, but also include the ACS in Resources/Agents in the same PR
   - If doing the above, all data must be `public const byte` and static. The variable name must be PascalCase (with underscores if necessary).
   - Start at 0 and increment by 1 for each animation
   - Please try your best to have the variable name and number order match the order of your animations, but it is ok if it slips through the cracks.
   - You can ask an admin or contributor to do the coding stuff for you if you just want to focus on the Agent creation
   - An Agent has a hard limit of 255 animations.
- No tolerance on pornographic content or nudity (sorry, no desktop strippers)
- No tolerance on racist, sexist, xenophobic, homophobic content or any content that could be perceived as harmfully stereotypical
- Slight tolerance on political figures and movements as long as it is not overtly hateful towards another group (will be explained if denied)
- Slight tolerance on violence and cartoon violence (please try to keep it PG-13, will be explained if denied)
- Copyrighted, Trademarked, Licensed characters are welcomed for sure but will be removed at the request of the character's owning party.

### Please Note
When submitting an issue, please note that we cannot address issues that target DoubleAgent, DoubleAgent SDK, ActiveX or MS Agent specific problems. DoubleAgent issues can be submitted to those developers directly, granted they are still working on the project. ActiveX and MS Agent issues... well not much we can do there. However, if you are capable of solving those issues yourself, by all means go ahead.

Some examples: 
- We cannot add animations to agents that don't exist within the file
- We can not direclty modify a function in any of the DoubleAgent DLLs

### And Finally, Be Mindful and Respectful (Some Code of Conduct Stuff and Some Rules)
- We have no tolerance for hateful language in Bug Reports, Feature Requests, Pull Requests, Commit Messages etc...
- Please try to foster a positive environment.
- Please try to foster an environment that promotes learning, growth and curiosity... this is simply a fun passion project after all.
- Please don't try to micromanage any existing or potential contributor(s). A lot of us have jobs, friends, families. Contribute at your own pace, doesn't matter if it takes 10 minutes or 3 months.
- Respect people's privacy and time.
- For testing and development purposes, please generate your own API Keys if necessary. Do not share your own or someone else's API Keys.
- Definitely DO NOT commit or submit a PR that includes potentially malicious or easily exploitable code. We know a lot of these agents used to be malware... that being said please report any potentially malicious code that slept through the cracks as an issue or directly to Michael (lethargie_sleeps)
- Most importantly, have fun! But if you do encounter any issues you can contact Michael directly =>  michaellandry@protonmail.com