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

out.times.data : main.exe
	>$@
	for N in $$(seq 100 20 200); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
	done

main.exe: main.cs QRGS.dll matrix.dll
		$(CSC) -reference:$(word 2,$^) $<

matrix.dll : vector.cs matrix.cs
		$(CSC) -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.cs vector.cs
		$(CSC) -target:library -out:$@ $^



clean:
		$(RM) *.dll *.exe [Oo]ut*

