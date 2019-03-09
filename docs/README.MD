# WordListAnalyzer Project

WELCOME! .

Please read the LICENSE.TXT and other docs in the /docs folder. 

## What's it for?
Primarily it was developed to assist optimizing stemming rules in various languages and for comparing stemmers. It compares two word lists of the same length, these are normally the input and out of a stemmer. It could however be useful for other purposes. It displays the input and output lists with measures of similarity and difference and calculates useful measures of stemmer strength, under and over stemming counts, and error rate relative to truncation (ERRT) according to the method described by Chris D Paice of Lancaster University.

## HISTORY
Word List Analyzer started life for internal use at 'dtSearch UK' while developing stemming rules for various languages for the dtSearch Engine, it was released in 2013 (as List Analyser 1.0 'beta' ) to customers of dtSearch Corp, 'dtSearch UK' and academic users free of charge; it is a single executable written in C# originally using the Open Source IDE SharpDevelop. http://www.icsharpcode.net/. The last update was in 2016 (1.1.5876 beta) which added Error Rate Relative to Truncation (ERRT), a method devised by Chris Paice of Lancaster University. The December 2018 Release build on GitHub v1.1.6916 was a rebuild using Visual Studio 2017, no code changes.

Chris Paice (1941 - 2016) Obituary http://wp.lancs.ac.uk/chrispaice/ .

While testing the ERRT calculations we discovered a couple of bugs in the Java Stemmer Test Software used at Lancaster University which gave errors in some published academic papers, consequently we added to the File>Preferences menu an option to emulate the bugs so that the results agree with the academic papers. 

## OPEN SOURCE RELEASE 2018
By releasing our code as open source, I hope that others will build on the work of Chris Paice and his colleagues. The Wiki contains a section on the errors mentioned above, and also references some later papers that improve on the original ERRT method. We decided to keep the status as 'beta' since the project was primarily for internal use and a limited number of external users, it performs well enough but contains 'hacks' as quick workarounds, it is definately not to 'production' standard; the lack of large 'grouped' word lists and limited academic papers with verified data on ERRT, etc. has meant that we are assuming that since our results agree very closely with the Lancaster University published papers that they are accurate. 

You are welcome to use this software for anything you choose, be it for academic research, commercial use, a hobby, or just out of curiosity! We hope that you will also contribute to this project, if you have suggestions for improvements or find bugs please raise an Issue here on GitHub, or email us at support@electronart.co.uk; The Master branch is protected to prevent deletion, please fork and request a pull once you've thouroughly tested your code, thank you. A Wiki contains the full content of the original WebHelp, and includes additional release notes, wish list and a contributors list.

A final note. There are some that like to promote the idea that there is some kind of 'war' between open source and closed source software companies, my point of view is that both have their place, and it's a case of 'horses for courses'; choose whatever does the job you want it to. We have used and contributed to both open source and closed source software for over 30 years, and were pioneers in 'shareware' distribution in the early '90s. Word List Analyzer has always been, and will continue to be, distributed by us free of charge. Please feel free to add your name to the List of Contributors if you find a bug, make an edit or use it in your research!

Kind Regards
Ray Harris BA MIET
Founder & CEO of ElectronArt Design Ltd
http://electronart.co.uk
http://www.dtsearch.co.uk/products/list-analyser.aspx
