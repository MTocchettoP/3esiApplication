# 3esiApplication
**********************************
Notes
**********************************
-Binaries have been excluded as requested.
-Full project is included, recompilation should be possible.
-Developed using VS 2017

**********************************
Test Suit
**********************************
-Test suit included, be sure to change the file paths in the FileManager test class

**********************************
Documentation
**********************************
- Full NDoc documentation can be found inside Doc/Help/Doc.chm
- Documentation was generated with SandCastle

**********************************
Application use
**********************************
- Application was developed as a console app with a simple menu.
- Supported operations:
	- Load a CSV file (1 file at a time)
	- Display loaded content
	- Exit
- Multiple files can be loaded in the same program run
- A summary of the load is displayed after each file is loaded
- Display loaded content will display the content of all files loaded during that program run
- Since the backend application is mocked there's no real persistence so all data is lost once program exits.
