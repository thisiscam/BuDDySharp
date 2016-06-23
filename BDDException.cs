using System;

namespace BuDDySharp {

    public class BDDException: Exception
    {
        public const int BDD_MEMORY =-1;   /* Out of memory */
        public const int BDD_VAR =-2;      /* Unknown variable */
        public const int BDD_RANGE =-3;    /* Variable value out of range (not in domain) */
        public const int BDD_DEREF =-4;    /* Removing external reference to unknown node */
        public const int BDD_RUNNING =-5;  /* Called bdd_init() twice whithout bdd_done() */
        public const int BDD_FILE =-6;     /* Some file operation failed */
        public const int BDD_FORMAT =-7;   /* Incorrect file format */
        public const int BDD_ORDER =-8;    /* Vars. not in order for vector based functions */
        public const int BDD_BREAK =-9;    /* User called break */
        public const int BDD_VARNUM =-10;  /* Different number of vars. for vector pair */
        public const int BDD_NODES =-11;   /* Tried to set max. number of nodes to be fewer */
                                  /* than there already has been allocated */
        public const int BDD_OP =-12;      /* Unknown operator */
        public const int BDD_VARSET =-13;  /* Illegal variable set */
        public const int BDD_VARBLK =-14;  /* Bad variable block operation */
        public const int BDD_DECVNUM =-15; /* Trying to decrease the number of variables */
        public const int BDD_REPLACE =-16; /* Replacing to already existing variables */
        public const int BDD_NODENUM =-17; /* Number of nodes reached user defined maximum */
        public const int BDD_ILLBDD =-18;  /* Illegal bdd argument */
        public const int BDD_SIZE =-19;    /* Illegal size argument */

        public const int BVEC_SIZE =-20;    /* Mismatch in bitvector size */
        public const int BVEC_SHIFT =-21;   /* Illegal shift-left/right parameter */
        public const int BVEC_DIVZERO =-22; /* Division by zero */

        public const int BDD_ERRNUM =24;

        private readonly int _errcode;

        public override string Message { 
            get {
                switch(_errcode) {
                    case BDD_MEMORY: 
                        return "Out of memory";
                    case BDD_VAR:
                        return "Unknown variable";
                    default:
                        return "Unknown error";
                }
            }
        }

        public BDDException(int errcode)
        {
            this._errcode = errcode;
        }

    }
}