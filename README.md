# prcreator
Create multiple GitHub PRs quicker with linking to JIRA.

This app will open multiple PRs from the same branch to multiple target branches. It will flag one of the PRs as the "main PR for review purposes", which will contain the main description and link to the JIRA bug (if any). The other PRs will simply link back to the main one to avoid multiple people reviewing the same thing in multiple places.

This app will also add comments to JIRA with the link to the various PRs and label them accordingly.

Ideally it would also set the bug to Pending Merge and maybe even log time.
