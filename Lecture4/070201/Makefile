Out.txt : main.exe main2.exe Makefile
	mono  main.exe  one two three > Out.txt
	mono main2.exe >> Out.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<

main2.exe: main2.cs
	mcs -target:exe -out:$@ $<


clean:
	$(RM) Out.txt main.exe
