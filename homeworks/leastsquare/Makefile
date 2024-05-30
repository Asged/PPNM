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

main.exe: main.cs QRGS.dll matrix.dll
		$(CSC) -reference:$(word 2,$^) $<

matrix.dll : vector.cs matrix.cs
		$(CSC) -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.cs vector.cs
		$(CSC) -target:library -out:$@ $^

radDecaygnuplot.svg : Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "radDecay.gnuplot.svg" ;\
		set xlabel "x" ;\
		set ylabel "Gamma(x)" ;\
		set yrange [0:120] ;\
		set grid ;\
		set title "Gamma Function" ;\
		plot \
			"radData.txt" with yerrorbars points pt 7 lc "blue" ps 1 title "Data Points"\
	'|tee log.gpi | gnuplot


clean:
		$(RM) *.dll *.exe [Oo]ut*

