SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
	RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
	CSC = mcs
	RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

library.dll: matrix.cs vector.cs QRGS.cs leastsquares.cs
	mcs -target:library -out:library.dll matrix.cs vector.cs QRGS.cs leastsquares.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs
																																			
rad.gnuplot.svg : radData.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "rel" ;\
		set grid ;\
		set title "Errorfunction" ;\
		plot \
			"radData.txt" with yerrorbars lt 7 lc rgb "purple" pointsize 1 notitle \
	'|tee log.gpi | gnuplot




clean:
		$(RM) *.dll *.exe [Oo]ut* *.svg *.png *.gpi

