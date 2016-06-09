## Commit Style
Each commit will be created by three parts:
- **type**
- **scope**
- **subject**

The scheme is:

| Field of commit  | Is looking            |
| -------------    |-----------------------|
| Title            | ```<type>(<scope>)``` |
| Description      | ```<subject>```       |

You should always use these of types for commits:

| Type         | Description                                                                                             |
| -------------|---------------------------------------------------------------------------------------------------------|
| **feat**     | A new feature.                                                                                          |
| **fix**      | A bug fix.                                                                                              |
| **docs**     | Documentation only changes.                                                                             |
| **style**    | Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc). |
| **refactor** | A code change that neither fixes a bug or adds a feature.                                               |
| **test**     | Adding missing tests.                                                                                   |
| **chore**    | Changes to the build process or auxiliary tools and libraries such as documentation generation.         |

The scope is specifying the place of the commit.

For the subject there are these rules:
- Use the imperative, present tense: "change" not "changed" nor "changes".
- Do not capitalize first letter.
- No dot (.) at the end.

Credit to: [somus](https://github.com/somus)
