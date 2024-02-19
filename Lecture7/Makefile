CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.Erf.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		plot \
			"$<" with lines \
			,"erf.data.txt" using 1:2 with points pointtype 6 \
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 ;\
	' | tee log.gpi | gnuplot

Out.txt : main.exe
	mono $< > $@

sfuns.dll : sfuns.cs ;$(MKLIB)
main.exe : main.cs sfuns.dll; $(MKEXE)

clean: 
	$(RM) *.exe *.dll [Oo]ut*  [Ll]og*
