using HerokuOperations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HerokuOperations.Pages
{{
    /// <summary>
    /// Page object for the Drag and Drop page.
    /// </summary>
    public class DragDrop : Idragdrop
    {
        private readonly IWebDriver _driver;

        private readonly By _header = By.TagName("h3");
        private readonly By _columnA = By.Id("column-a");
        private readonly By _columnB = By.Id("column-b");

        public DragDrop(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <inheritdoc/>
        public string GetTitle()
        {
            return _driver.Title;
        }

        /// <inheritdoc/>
        public string GetColumnAText()
        {
            return _driver.FindElement(_columnA).Text;
        }

        /// <inheritdoc/>
        public string GetColumnBText()
        {
            return _driver.FindElement(_columnB).Text;
        }

        /// <inheritdoc/>
        public void DragAtoB()
        {
            IWebElement source = _driver.FindElement(_columnA);
            IWebElement target = _driver.FindElement(_columnB);

            DragAndDrop(source, target);
        }

        /// <inheritdoc/>
        public void DragBtoA()
        {
            IWebElement source = _driver.FindElement(_columnB);
            IWebElement target = _driver.FindElement(_columnA);

            DragAndDrop(source, target);
        }

        /// <summary>
        /// Performs drag-and-drop action using JavaScript.
        /// </summary>
        private void DragAndDrop(IWebElement source, IWebElement target)
        {
            string script = @"
                function createEvent(typeOfEvent) {
                    var event = document.createEvent('CustomEvent');
                    event.initCustomEvent(typeOfEvent, true, true, null);
                    event.dataTransfer = {
                        data: {},
                        setData: function(key, value) {
                            this.data[key] = value;
                        },
                        getData: function(key) {
                            return this.data[key];
                        }
                    };
                    return event;
                }

                function dispatchEvent(element, event, transferData) {
                    if (transferData !== undefined) {
                        event.dataTransfer = transferData;
                    }
                    element.dispatchEvent(event);
                }

                function simulateHTML5DragAndDrop(element, target) {
                    var dragStartEvent = createEvent('dragstart');
                    dispatchEvent(element, dragStartEvent);
                    
                    var dropEvent = createEvent('drop');
                    dispatchEvent(target, dropEvent, dragStartEvent.dataTransfer);
                    
                    var dragEndEvent = createEvent('dragend');
                    dispatchEvent(element, dragEndEvent, dragStartEvent.dataTransfer);
                }

                simulateHTML5DragAndDrop(arguments[0], arguments[1]);
            ";

            ((IJavaScriptExecutor)_driver).ExecuteScript(script, source, target);
        }
    }
}