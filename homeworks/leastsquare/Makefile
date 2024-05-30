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

main.exe: main.cs leastsquare.dll
		$(CSC) -reference:$(word 2,$^) $<

leastsquare.dll : leastsquare.cs QRGS.cs matrix.cs vector.cs
		$(CSC) -target:library -out:$@ $^

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

