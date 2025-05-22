<?php
if (!isset($_SESSION['nomes'])) {
    $_SESSION['nomes'] = json_decode(file_get_contents('nome.json'), true);
}

$num = count($_SESSION['nomes']);
echo "<b style='font-size: 127px; '>".$num."</b>";
?>
