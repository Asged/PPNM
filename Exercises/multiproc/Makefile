CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$nthreads %e %U" 

Out.times.svg : out.times.txt
	echo '\
		set terminal svg background "white" ;\
		set out"$@" ;\
		set xlabel "number of threads" ;\
		set ylabel "real time" ;\
		plot "$<" with lp ;\
		'|tee log.gpi | gnuplot

N = 1e9
out.times.txt : main.exe Makefile
	>$@
	for nthreads in $$(seq 1 16); do\
		$(TIME) mono main.exe -nthreads:$$nthreads -nterms:$(N); \
	done
out2.times.txt : main2.exe Makefile
	>$@ $(TIME) mono main2.exe -nterms:$N
out3.times.txt : main3.exe Makefile
	>$@ $(TIME) mono main3.exe -nterms:$N

main.exe : main.cs; 
	$(MKEXE)
main2.exe : main2.cs
	$(MKEXE)
main3.exe : main3.cs
	$(MKEXE)

test : out1 out2 out3 out4

N=1e8
Out.txt : main.exe Makefile
	>$@
	$(TIME) mono $< -terms:$N -threads:1 >>$@
	$(TIME) mono $< -terms:$N -threads:2 >>$@
	$(TIME) mono $< -terms:$N -threads:3 >>$@
	$(TIME) mono $< -terms:$N -threads:4 >>$@

clean :
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
