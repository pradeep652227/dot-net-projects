function onClickSelect() {
    let globalJobId = document.getElementById("jobSelect").value;
    console.log(`Selected Job with Id= ${globalJobId}`);
    //Get JobList to filter out the innerHtml
    var jobItems = Array.from(document.getElementsByClassName("job-item"));

    var matchingJobs = jobItems.filter(job => {
        return job.getAttribute("data-id") == globalJobId;
    })

    var nonMatchingJobs = jobItems.filter(job => {
        return job.getAttribute("data-id") != globalJobId;
    })
    let jobList = document.getElementById("jobList");
    //emptying the current order
    jobList.innerHTML = "";

    matchingJobs.map(job => jobList.appendChild(job));
    nonMatchingJobs.map(job => jobList.appendChild(job));
}