Out.txt : main.exe main2.exe
	mono main.exe > Out.txt

main.exe : main.cs
	mcs -target:exe -out:main.exe main.cs

main2.exe : main2.cs
	mcs -target:exe -out:main2.exe main2.cs

clean :
	rm -f *.exe *.txt
