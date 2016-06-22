CMAKE_MINIMUM_REQUIRED(VERSION 3.0)

project(buddysharp)

add_subdirectory(buddy)

FIND_PACKAGE(SWIG REQUIRED)
INCLUDE(${SWIG_USE_FILE})

SET(BUDDY_ROOT_DIR "buddy")

INCLUDE_DIRECTORIES(${CMAKE_CURRENT_SOURCE_DIR}/${BUDDY_ROOT_DIR}/src)

set(CMAKE_SWIG_OUTDIR "generated")
SET(CMAKE_SWIG_FLAGS "-namespace" "buddysharp")

SWIG_ADD_MODULE(bdd csharp bdd.i)
SWIG_LINK_LIBRARIES(bdd buddy)

add_custom_command(TARGET ${SWIG_MODULE_bdd_REAL_NAME} POST_BUILD
                   COMMAND ${CMAKE_COMMAND} -E copy
                   ${CMAKE_SOURCE_DIR}/bdd_ext.cs ${swig_outdir})