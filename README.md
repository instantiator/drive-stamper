# drive-stamper

Drive Stamper is a Windows tool for detecting detachable drives, and pushing files onto them automatically.

It's ideal for a small promotion or a small business that needs to quickly distribute the same files onto a lot of media units and wishes to save costs by doing it themselves.

The application, once loaded, will monitor your system for new drives and (if they have not already been stamped) will copy the files you specify onto the drive.

This tool was built in 2011, and published in 2015. I can't make any guarantees about its usability beyond Windows XP - but stranger things have happened!

## Installation

* Download the installer: [Release 1.0](https://github.com/instantiator/drive-stamper/releases/tag/1.0)

## Usage

On load, you are presented with the Drives view - a window showing all drives the system is currently monitoring.

Note that unless you alter the current project to allow it, Drive Stamper will ignore drives `A`, `B`, `C` and `D` as these are usually letters that signify where the floppy drives used to be (`A` and `B`), where the main hard drive is (`C`), and where the main CD-drive is (`D`) - drives that make sense to ignore.

In the screenshot on the right, drive `E` has been detected and is noted to already be stamped.

Note that when there is no project loaded, or when there are no files in the current project, all drives will appear to be stamped as there is nothing to check for!

As you can see, there are 3 modes for Drive Stamper, selectable from the 3 radio button at the top of the view: **Automatic**, **Semi-Automatic**, and **Manual**.

* **Automatic:** Drive Stamper will automatically try to stamp any new unstamped drive it comes across (not included in the ignore list).
* **Semi-Automatic:** Whenever Drive Stamper detects a new drive that qualifies for stamping, it will ask you if you want to stamp it.
* **Manual:** Drive Stamper will quietly detect new drives and wait for you to press the Stamp button on the Drives screen to stamp any new drives.

If at any time you think Drive Stamper has failed to notice a drive add or remove, you can refresh the list of drives using the Refresh button at the bottom of the view.

To specify some files for Drive Stamper to use, press the **Edit...** button to open the Project view.

The main component of the project view is a list of files to be stamped (copied) onto any new drives.

* To add files to it, click: **Add Files...**
* To remove a file from it, click the file and select: **Remove**

In this screenshot it is empty (as you would expect to find it).

If the **Ignore missing files** checkbox is checked, Drive Stamper will proceed to stamp a drive even if it cannot find all the files specified for the project - skipping over those it cannot find.

If the **Overwrite files** checkbox is checked, Drive Stamper will deliberately copy the specified files onto the drive, and overwrite any files with the same names that are already there.

In the bottom right corner of the window is the **Ignore Drives** box - containing a list of drive letters to ignore. By default, a, b, c, and d are selected - as these drives are commonly where the floppy drives were mapped (a and b), where the main hard drive is mapper (c) and where the main CD drive is mapped (d). You can alter these defaults and enable or disable the ignore function for any drive letters from a-z by checking or unchecking their boxes.

When done you can save the project from the **Project** menu.

On returning to the drives screen, you will note that the project name has now been updated, and any drives that may have seemed stamped will be shown as Ready instead.

Drive Stamper will continue to run after you close the Drives view - and it has an icon in the system tray (it uses the blue round information 'i' icon) from which you can open the Drives and Project views using the right-click menu.

## Supporting tools

The installer was built using [InstallSimple](http://www.installsimple.com/) (free edition).
