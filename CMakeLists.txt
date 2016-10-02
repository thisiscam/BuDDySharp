CMAKE_MINIMUM_REQUIRED(VERSION 3.0)

project(buddysharp)

add_subdirectory(buddy)

FIND_PACKAGE(SWIG REQUIRED)
INCLUDE(${SWIG_USE_FILE})

SET(BUDDY_ROOT_DIR "buddy")

INCLUDE_DIRECTORIES(${CMAKE_CURRENT_SOURCE_DIR}/${BUDDY_ROOT_DIR}/src)

set(CMAKE_SWIG_OUTDIR "generated")
SET(CMAKE_SWIG_FLAGS "-namespace" "BuDDySharp" "-larrays_csharp.i" "-lcarrays.i")

SET_SOURCE_FILES_PROPERTIES(buddysharp.i PROPERTIES CPLUSPLUS ON)
SWIG_ADD_MODULE(buddysharp csharp buddysharp.i)
SWIG_LINK_LIBRARIES(buddysharp buddy_shared)

add_custom_command(TARGET ${SWIG_MODULE_buddysharp_REAL_NAME} POST_BUILD
                   COMMAND ${CMAKE_COMMAND} -E copy
                   ${CMAKE_SOURCE_DIR}/bdd_ext.cs ${CMAKE_SOURCE_DIR}/BDDException.cs 
                   ${swig_outdir})