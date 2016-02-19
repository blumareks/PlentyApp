# PlentyApp
This an app for the Interconnect written in C# to connect to the MFP and StrongLoop to consume resources with an OAuth token exchange.

Some instructions:
STEP 1: update C# file in Plenty.Droid/MainActivity.cs - match IP in the URL of the URL_STRONGLOOP constant with the existing VMWare environment (for example: "http://192.168.0.105:3000/api/"; )

STEP 2: update MFP file in Plenty.Droid/Assets/wlclient.properties - match wlServerHost with the existing VMWare environment (for example: 192.168.0.105 )

STEP 3: cd c:\LabFiles\strongloop\plenty-api\ and run Strongloop command: node .

STEP 4: cd c:\LabFiles\mfp\plenty and run command: mfp start

STEP 5. validate hybrid application working: cd c:\LabFiles\mfp\plentytest and run command: mfp cordova preview
(please remember to adjust the worklight.properties file to reflect the VM ip)
C:\LabFiles\mfp\plentytest\platforms\android\assets\wlclient.properties
C:\LabFiles\mfp\plentytest\www\js\index.js 

STEP 6: enter the directory C:\LabFiles\mfp\plenty
from the MFP console (issue 'mfp console' command) delete androidPlenty API 
and then create a new API : mfp add api androidPlenty -e android
then push the API to mfp server: mfp push (before that issue "mfp start" command)


Attention - it is possible to avoid recreating the MFP API to get the Token o.k. - in order to do it please comment the 36 i 37 line of c:\LabFiles\strongloop\strongloop-api\server.js
line 36 commented looks like this:
// app.use('/api/Offers', auth('PlentyAppRealm'), cont);

STEP 7: connect NEXUS10 (or emulator) and deploy plenty app for Android



STEP 8: insert any password (at least 1 character), and access home screen with offers and events from the menu  - "hamburger" - icon (the large size of the pictures hangs the image)

STEP 9: Check also the Application Output for any errors, and look for the MFP log and analytics being sent by the platform.
see the video : https://ibm.box.com/s/w52tu590xbfn819mtnhqlirzzrgw19nz
get the environment plenty copy 2.zip: https://ibm.box.com/s/8s0iy2l8tj10j2ph7iwkutph74fl0ult

FAQ:
Some typical errors:
- the plenty app can't connect to the MFP back-end: please restart the environment
- the plenty app can't connect to the StrongLoop back-end: please recreate the API (revisit step 6, or disable security protection protection - an "attention" suggestion of the step 6)
- the app (on the device - both real and emulated) can't connect - manually remove the app from the environment

The updated file with pictures: https://ibm.box.com/s/woku104wfvpoxoe8urj4at6sbg4yln74

