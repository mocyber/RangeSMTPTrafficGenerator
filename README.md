# SMTP Traffic Generation - Range Tool

This tool will allow you to install a service which generates (somewhat) realistic email traffic for range. We use this tool to generate cover traffic and simulate email in our enclaves.

Couple of notes:

* Make sure you configure the Settings in app.config 
* You'll need to configure valid email addresses from mail systems in the recipients.txt file. Both sender and reciever are drawn from this. (inter-enclave communication)
* You can adjust the dictionary file to contain words and phrases you want to be injected into the mail body. This can include links, or whatever you want, just separate by lines.


To install:

If you're using a compiled version, just copy the files to a directory, then execute 'SMTPTrafficGenerator install'. This installs a windows service that you can start.


For support, create an issue.