function downloadFileFromUrl(url) {
    const link = document.createElement('a');
    link.href = url;
    link.download = 'clients_export.csv'; 
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
