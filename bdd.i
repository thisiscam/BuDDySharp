%define %cs_callback(TYPE, CSTYPE) 
        %typemap(ctype) TYPE, TYPE& "void*" 
        %typemap(in) TYPE  %{ $1 = (TYPE)$input; %} 
        %typemap(in) TYPE& %{ $1 = (TYPE*)&$input; %} 
        %typemap(imtype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
        %typemap(cstype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
        %typemap(csin) TYPE, TYPE& "$csinput" 
%enddef

%apply void *VOID_INT_PTR { void * }

%cs_callback(bddinthandler, bddinthandler)
%cs_callback(bddgbchandler, bddgbchandler)
%cs_callback(bdd2inthandler, bdd2inthandler)
%cs_callback(bddinthandler, bddinthandler)
%cs_callback(bddfilehandler, bddfilehandler)

%module bdd
%{
	/* Includes the header in the wrapper code */
	#include "bdd.h"
%}
 
%pragma(csharp) moduleclassmodifiers= "public partial class"
%csmethodmodifiers bdd_error_hook "protected";
%csmethodmodifiers bdd_error_hook "protected";
%csmethodmodifiers  bdd_gbc_hook "protected";
%csmethodmodifiers bdd_resize_hook "protected";
%csmethodmodifiers  bdd_reorder_hook "protected";
%csmethodmodifiers bdd_file_hook "protected";
%csmethodmodifiers bdd_blockfile_hook "protected";
%csmethodmodifiers bdd_strm_hook "protected"

/* Parse the header file to generate wrappers */
%include "bdd.h"

