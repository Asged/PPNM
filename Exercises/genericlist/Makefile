Out.txt : main.exe
	mono main.exe < genlist.txt > Out.txt

main.exe : main.cs
	mcs -target:exe -out:main.exe main.cs

clean : 
	rm -f Out.txt main.exe
