import numpy

a = numpy.zeros((10,1))
a[:,0] = numpy.nan
print(a[0,0] is numpy.nan)
b = numpy.ones((10,1))
print(a,b)
c = numpy.column_stack((a, b)) 
c = numpy.column_stack((c, b))
print(c,c.shape)
d = numpy.nansum(c,axis = 1)
print(d,d.shape)
