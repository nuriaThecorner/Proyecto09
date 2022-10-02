<?php

function conexion(){
    return mysqli_connect("localhost", "Usuario", "U5U4R10", "ProyectoMusica");
}

$id = 0;
if($_GET['id'] != null){		   
   $id = $_GET['id'];
}
/*echo $id;*/
$conexion = conexion();
$sql = "";
if($id>0){
	$sql = "SELECT * FROM `Autor` WHERE `id` = " . $id;
}else{
	$sql = "SELECT * FROM `Autor`";
}

$resultado = mysqli_query($conexion,$sql);
$datos = mysqli_fetch_all($resultado,MYSQLI_ASSOC);

if(!empty($datos)){
    echo json_encode($datos);
}else{
    echo json_encode([]);
}