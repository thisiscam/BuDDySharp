%define %cs_callback(TYPE, CSTYPE) 
        %typemap(in) TYPE  %{ $1 = (TYPE)$input; %} 
        %typemap(in) TYPE& %{ $1 = (TYPE*)&$input; %} 
        %typemap(imtype, out="System.IntPtr") TYPE, TYPE& "CSTYPE" 
        %typemap(cstype, out="System.IntPtr") TYPE, TYPE& "CSTYPE" 
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

%pragma(csharp) moduleimports= %{
using System;
%}

%pragma(csharp) moduleclassmodifiers= "public partial class"
%rename(bdd_error_hook) bdd_error_hook_csharp;
%rename(bdd_gbc_hook)  bdd_gbc_hook_csharp;
%rename(bdd_resize_hook) bdd_resize_hook_csharp;
%rename(bdd_reorder_hook)  bdd_reorder_hook_csharp;
%rename(bdd_file_hook) bdd_file_hook_csharp;
%rename(bdd_blockfile) bdd_blockfile_csharp;
%rename(bdd_strm_hook) bdd_strm_hook_csharp;
%rename(bdd_blockfile_hook) bdd_blockfile_hook_csharp;

%csmethodmodifiers bdd_error_hook_csharp "protected";
%csmethodmodifiers bdd_error_hook_csharp "protected";
%csmethodmodifiers bdd_gbc_hook_csharp "protected";
%csmethodmodifiers bdd_resize_hook_csharp "protected";
%csmethodmodifiers  bdd_reorder_hook_csharp "protected";
%csmethodmodifiers bdd_file_hook_csharp "protected";
%csmethodmodifiers bdd_blockfile_hook_csharp "protected";

%inline %{
	void bdd_error_hook_csharp(bddinthandler arg0) {
		bdd_error_hook(arg0);
	}
	void  bdd_gbc_hook_csharp(bddgbchandler arg0) {
		bdd_gbc_hook(arg0);
	}
	void bdd_resize_hook_csharp(bdd2inthandler arg0) {
		bdd_resize_hook(arg0);
	}
	void  bdd_reorder_hook_csharp(bddinthandler arg0) {
		bdd_reorder_hook(arg0);
	}
	void bdd_file_hook_csharp(bddfilehandler arg0) {
		bdd_file_hook(arg0);
	}
	void bdd_blockfile_hook_csharp(bddfilehandler arg0) {
		bdd_blockfile_hook(arg0);
	}
%}

%ignore bdd_error_hook;
%ignore bdd_error_hook;
%ignore bdd_gbc_hook;
%ignore bdd_resize_hook;
%ignore bdd_reorder_hook;
%ignore bdd_file_hook;
%ignore bdd_blockfile;
%ignore bdd_strm_hook;

/* Parse the header file to generate wrappers */
%include "bdd.h"

