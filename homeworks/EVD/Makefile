Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs matvec.dll
	mcs -target:exe -out:main.exe -reference:matvec.dll main.cs

mainB.exe : mainB.cs main.exe matvec.dll

matvec.dll : matrix.cs vector.cs
	mcs -target:library -out:matvec.dll matrix.cs vector.cs

drVariation.txt : main.exe Makefile
	>$@
	>log.dr
	for drV in $$(seq 0.1 0.05 0.3); do \
		echo $$drV; \
		mono main.exe -rmax:10 -dr:$$drV >> log.dr; \
	done; \

rmaxVariation.txt : main.exe Makefile
	for rmaxV in $$(seq 1 1 20); do \
		mono main.exe -rmax:$$rmaxV -dr:0.3 >> rmaxVariation.txt; \
	done; \

target:
	for drV in $$(seq 0.1 0.1 1); do \
		echo $$drV; \
	done;

clean:
	rm -f *.dll *.txt main.exe
