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

main.exe: main.cs
		$(CSC) $<

clean:
		$(RM) *.dll *.exe [Oo]ut*